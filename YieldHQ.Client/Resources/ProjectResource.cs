using YieldHQ.Client.Models;
using YieldHQ.Client.Models.Project;

namespace YieldHQ.Client.Resources;

/// <summary>Provides access to the Project API.</summary>
public class ProjectResource : ResourceBase
{
    internal ProjectResource(HttpClient http) : base(http) { }

    // Projects
    /// <summary>List projects.</summary>
    public Task<PagedResult<Project>> ListAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<Project>("/api/v1/project/projects", query, ct);

    /// <summary>Get a single project by ID.</summary>
    public Task<Project> GetAsync(int id, CancellationToken ct = default) =>
        GetAsync<Project>($"/api/v1/project/projects/{id}", ct);

    /// <summary>Create a new project.</summary>
    public Task<int> CreateAsync(Project project, CancellationToken ct = default) =>
        CreateAsync<int>("/api/v1/project/projects", project, ct);

    /// <summary>Update a project.</summary>
    public Task UpdateAsync(int id, Project project, CancellationToken ct = default) =>
        UpdateAsync($"/api/v1/project/projects/{id}", project, ct);

    /// <summary>Archive (soft-delete) a project.</summary>
    public Task ArchiveAsync(int id, CancellationToken ct = default) =>
        DeleteAsync($"/api/v1/project/projects/{id}", ct);

    /// <summary>List milestones for a project.</summary>
    public Task<PagedResult<ProjectMilestone>> ListMilestonesAsync(int projectId, QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<ProjectMilestone>($"/api/v1/project/projects/{projectId}/milestones", query, ct);

    /// <summary>Create a milestone for a project.</summary>
    public Task<int> CreateMilestoneAsync(int projectId, ProjectMilestone milestone, CancellationToken ct = default) =>
        CreateAsync<int>($"/api/v1/project/projects/{projectId}/milestones", milestone, ct);

    // Tasks
    /// <summary>List tasks with optional project/stage filters.</summary>
    public Task<PagedResult<ProjectTask>> ListTasksAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<ProjectTask>("/api/v1/project/tasks", query, ct);

    /// <summary>Get a single task by ID.</summary>
    public Task<ProjectTask> GetTaskAsync(int id, CancellationToken ct = default) =>
        GetAsync<ProjectTask>($"/api/v1/project/tasks/{id}", ct);

    /// <summary>Create a new task.</summary>
    public Task<int> CreateTaskAsync(ProjectTask task, CancellationToken ct = default) =>
        CreateAsync<int>("/api/v1/project/tasks", task, ct);

    /// <summary>Update a task.</summary>
    public Task UpdateTaskAsync(int id, ProjectTask task, CancellationToken ct = default) =>
        UpdateAsync($"/api/v1/project/tasks/{id}", task, ct);

    /// <summary>Move a task to a specific stage.</summary>
    public Task MoveTaskToStageAsync(int id, int stageId, CancellationToken ct = default) =>
        ActionAsync($"/api/v1/project/tasks/{id}/stage", stageId, ct);

    /// <summary>Close a task.</summary>
    public Task CloseTaskAsync(int id, CancellationToken ct = default) =>
        ActionAsync($"/api/v1/project/tasks/{id}/close", ct: ct);

    // Stages
    /// <summary>List task stages.</summary>
    public Task<PagedResult<TaskStage>> ListStagesAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<TaskStage>("/api/v1/project/stages", query, ct);

    /// <summary>Create a new stage.</summary>
    public Task<int> CreateStageAsync(TaskStage stage, CancellationToken ct = default) =>
        CreateAsync<int>("/api/v1/project/stages", stage, ct);

    // Tags
    /// <summary>List project tags.</summary>
    public Task<PagedResult<ProjectTag>> ListTagsAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<ProjectTag>("/api/v1/project/tags", query, ct);
}
